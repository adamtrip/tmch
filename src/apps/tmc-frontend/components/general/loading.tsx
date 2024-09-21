import { cn } from '@/lib/utils';
import { Loader2Icon } from 'lucide-react';

interface LoadingProps {
  showText?: boolean;
  className?: string;
}

export default function Loading({ showText = true, className }: LoadingProps) {
  return (
    <div className={cn('', className)}>
      <div className={'flex items-center justify-center'}>
        <Loader2Icon className="h-10 w-10 animate-spin" />
      </div>
      {showText && (
        <div className={'flex items-center justify-center'}>
          <span className="text-sm text-muted-foreground">Loading...</span>
        </div>
      )}
    </div>
  );
}
